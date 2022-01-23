import { QueryObserverResult, useQuery } from "react-query";
import { Client } from "../../services/generatedServices";
import queryStoreKeys from "../queryStoreKeys";

const useGet = (): QueryObserverResult<boolean> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.IDENTITY_GET,
        queryFn: async () => {
            return await client.identityGet();
        },
    });
};

const identityQueryStore = { useGet };

export default identityQueryStore;
