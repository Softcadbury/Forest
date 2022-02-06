import { QueryObserverResult, useMutation, UseMutationResult, useQuery, useQueryClient } from "react-query";
import { Client, Tree, TreePost } from "../../services/generatedServices";
import queryStoreKeys from "../queryStoreKeys";

const useGet = (id: string | undefined): QueryObserverResult<Tree> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.TREES_GET,
        queryFn: async () => await client.treeGet(id!),
        enabled: !!id,
    });
};

const useGetAll = (): QueryObserverResult<Tree[]> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.TREES_GET_ALL,
        queryFn: async () => await client.treeGetAll(),
    });
};

const useCreate = (): UseMutationResult<Tree, unknown, TreePost, unknown> => {
    const client = new Client();
    const queryClient = useQueryClient();

    return useMutation(async (tree) => await client.treeCreate(tree), {
        onSuccess: (result: Tree) => {
            queryClient.setQueryData<Tree[]>(queryStoreKeys.TREES_GET_ALL, (old) => (old ? [result, ...old] : []));
        },
        // todo - handle onError
    });
};

const treeQueryStore = { useGet, useGetAll, useCreate };

export default treeQueryStore;
