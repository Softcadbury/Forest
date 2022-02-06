import { useContext } from "react";
import { ResourcesContext } from "../common/providers/ResourcesProvider";

export const useResources = () => {
    const resources = useContext(ResourcesContext);

    if (!resources) {
        throw new Error("Resources not loaded");
    }

    return resources;
};
