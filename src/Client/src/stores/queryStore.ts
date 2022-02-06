import identityQueryStore from "./identity/identityQueryStore";
import resourcesQueryStore from "./resources/resourcesQueryStore";
import treeNodeQueryStore from "./tree-node/treeNodeQueryStore";
import treeQueryStore from "./tree/treeQueryStore";

export const useQueryStore = () => ({
    identityStore: identityQueryStore,
    resourcesQueryStore: resourcesQueryStore,
    treeStore: treeQueryStore,
    treeNodeStore: treeNodeQueryStore,
});
