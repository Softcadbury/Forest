import { CircularProgress } from "@mui/material";
import { createContext } from "react";
import { Resources } from "../../services/generatedServices";
import { useQueryStore } from "../../stores/queryStore";

export const ResourcesContext = createContext<Resources | null>(null);

export const ResourcesProvider: React.FC = ({ children }) => {
    const { resourcesQueryStore } = useQueryStore();
    const { data, isLoading } = resourcesQueryStore.useGet();

    if (isLoading || !data) return <CircularProgress />;

    return <ResourcesContext.Provider value={data}>{children}</ResourcesContext.Provider>;
};
