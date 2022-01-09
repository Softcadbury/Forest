import { QueryObserverResult, useQuery } from "react-query";
import { Client, Tree } from "../../services/generated-services";
import queryStoreKeys from "../query-store-keys";

const useGet = (id: string | undefined): QueryObserverResult<Tree> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.TREES_GET,
        queryFn: async () => {
            return await client.treeGet(id!);
        },
        enabled: !!id,
    });
};

const useGetAll = (): QueryObserverResult<Tree[]> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.TREES_GET_ALL,
        queryFn: async () => {
            return await client.treeGetAll();
        },
    });
};

const treeQueryStore = { useGet, useGetAll };

export default treeQueryStore;
