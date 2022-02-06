import { QueryObserverResult, useQuery } from "react-query";
import { Client, Resources } from "../../services/generatedServices";
import queryStoreKeys from "../queryStoreKeys";

const useGet = (): QueryObserverResult<Resources> => {
    const client = new Client();

    return useQuery({
        queryKey: queryStoreKeys.RESOURCES_GET,
        queryFn: async () => await client.resourcesGet(),
        cacheTime: Infinity,
    });
};

const resourcesQueryStore = { useGet };

export default resourcesQueryStore;
