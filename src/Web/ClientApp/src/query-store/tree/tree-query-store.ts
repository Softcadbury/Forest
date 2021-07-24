import { QueryObserverResult, useQuery } from "react-query";
import { Client, TreeViewModel } from "../../services/generated-services";
import queryStoreKeys from "../query-store-keys";

const useGet = (
    uuid: string | undefined
): QueryObserverResult<TreeViewModel> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.TREES_GET,
        queryFn: async () => {
            return await client.treeGet(uuid!);
        },
        enabled: !!uuid,
    });
};

const useGetAll = (): QueryObserverResult<TreeViewModel[]> => {
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
