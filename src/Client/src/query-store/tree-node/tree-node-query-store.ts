import { QueryObserverResult, useMutation, UseMutationResult, useQuery, useQueryClient } from "react-query";
import { Client, NodePost, Tree, TreePost } from "../../services/generated-services";
import queryStoreKeys from "../query-store-keys";

const useGetAll = (treeId: string | undefined): QueryObserverResult<Node[]> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.TREE_NODES_GET_ALL,
        queryFn: async () => {
            return await client.treeNodeGetAll(treeId!);
        },
        enabled: !!treeId,
    });
};

const useCreate = (): UseMutationResult<Tree, unknown, { treeId: string; node: NodePost }, unknown> => {
    const client = new Client();
    const queryClient = useQueryClient();

    return useMutation(
        async ({ treeId, node }) => {
            return await client.treeNodeCreate(treeId, node);
        },
        {
            onSuccess: (result: Tree) => {
                queryClient.setQueryData<Tree[]>(queryStoreKeys.TREE_NODES_GET_ALL, (old) =>
                    old ? [result, ...old] : []
                );
            },
            // todo - handle onError
        }
    );
};

const treeQueryStore = { useGetAll, useCreate };

export default treeQueryStore;
