import { QueryObserverResult, useQuery } from "react-query";
import { Client, Tree } from "../services/generated-services";
import queryStoreKeys from "./query-store-keys";

const useGetTrees = (): QueryObserverResult<Tree[]> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.GET_TREES,
        queryFn: async () => {
            return await client.treeGetAll();
        },
    });
};

const treeQueryStore = {
    useGetTrees,
};

export default treeQueryStore;
