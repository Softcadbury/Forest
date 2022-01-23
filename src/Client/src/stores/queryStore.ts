import identityQueryStore from "./identity/identityQueryStore";
import treeNodeQueryStore from "./tree-node/treeNodeQueryStore";
import treeQueryStore from "./tree/treeQueryStore";

export const useQueryStore = () => ({
    identityStore: identityQueryStore,
    treeStore: treeQueryStore,
    treeNodeStore: treeNodeQueryStore,
});
