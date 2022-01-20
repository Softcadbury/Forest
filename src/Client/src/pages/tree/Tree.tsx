import { CircularProgress, CardContent, Card, Button } from "@material-ui/core";
import styled from "styled-components";
import { useRouteMatch } from "react-router-dom";
import { useQueryStore } from "../../query-store/query-store";
import { useCallback } from "react";
import { NodePost } from "../../services/generated-services";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Tree() {
    const match = useRouteMatch<{ id: string }>("/trees/:id");
    const id = match?.params.id;

    const { treeStore, treeNodeStore } = useQueryStore();
    const { data: tree } = treeStore.useGet(id);
    const { data: nodes } = treeNodeStore.useGetAll(tree?.id);
    const { mutate: onCreateNode } = treeNodeStore.useCreate();

    const onClickCreateNode = useCallback(() => {
        var node = new NodePost({ label: "node" });
        tree?.id && onCreateNode({ treeId: tree.id, node });
    }, [onCreateNode, tree]);

    if (!tree || !nodes) return <CircularProgress />;

    return (
        <>
            <StyledCard>
                <CardContent>{tree.label}</CardContent>
            </StyledCard>
            {nodes.map((node) => (
                <StyledCard key={node.id}>
                    <CardContent>{node.label}</CardContent>
                </StyledCard>
            ))}
            <Button onClick={onClickCreateNode}>+ Add</Button>
        </>
    );
}

export default Tree;
