import identityQueryStore from "./identity/identity-query-store";
import treeQueryStore from "./tree/tree-query-store";

export const useQueryStore = () => ({
    identityStore: identityQueryStore,
    treeStore: treeQueryStore,
});
