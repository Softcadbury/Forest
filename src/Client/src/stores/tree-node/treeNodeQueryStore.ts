import { QueryObserverResult, useMutation, UseMutationResult, useQuery, useQueryClient } from "react-query";
import { Client, NodePost, Tree, Text } from "../../services/generatedServices";
import queryStoreKeys from "../queryStoreKeys";

const useGetAll = (treeId: string | undefined): QueryObserverResult<Node[]> => {
    const client = new Client();

    return useQuery({
        queryKey: [queryStoreKeys.TREE_NODES_GET_ALL, treeId],
        queryFn: async () => await client.treeNodeGetAll(treeId!),
        enabled: !!treeId,
    });
};

const useGetPrettyPrint = (treeId: string | undefined): QueryObserverResult<Text> => {
    const client = new Client();

    return useQuery({
        queryKey: [queryStoreKeys.TREE_NODES_GET_PRETTY_PRINT, treeId],
        queryFn: async () => await client.treeNodeGetPrettyPrint(treeId!),
        enabled: !!treeId,
    });
};

const useCreate = (treeId: string): UseMutationResult<Tree, unknown, { node: NodePost }, unknown> => {
    const client = new Client();
    const queryClient = useQueryClient();

    return useMutation(async ({ node }) => await client.treeNodeCreate(treeId, node), {
        onSuccess: (result: Tree) => {
            queryClient.setQueryData<Tree[]>([queryStoreKeys.TREE_NODES_GET_ALL, treeId], (old) =>
                old ? [...old, result] : []
            );
            queryClient.invalidateQueries([queryStoreKeys.TREE_NODES_GET_PRETTY_PRINT, treeId]);
        },
        // todo - handle onError
    });
};

const treeQueryStore = { useGetAll, useGetPrettyPrint, useCreate };

export default treeQueryStore;
