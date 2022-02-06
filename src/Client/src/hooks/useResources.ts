import { useContext } from "react";
import { ResourcesContext } from "../common/providers/ResourcesProvider";
import { Resources } from "../services/generatedServices";

export const useResources = (): Resources => {
    const resources = useContext(ResourcesContext);

    if (!resources) {
        throw new Error("Resources not loaded");
    }

    return resources;
};
