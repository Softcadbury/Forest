import { CircularProgress, CardContent, Card, Button, Typography, Grid } from "@mui/material";
import { useRouteMatch } from "react-router-dom";
import { useQueryStore } from "../../query-store/query-store";
import { useCallback } from "react";
import { NodePost } from "../../services/generated-services";

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
            <Typography variant="h6" sx={{ marginBottom: 1 }}>
                {tree.label}
                <Button onClick={onClickCreateNode} sx={{ float: "right" }}>
                    + Add
                </Button>
            </Typography>
            <Grid container spacing={2}>
                {nodes.map((node) => (
                    <Grid item xs={3} md={3} key={node.id}>
                        <Card>
                            <CardContent>
                                <Typography variant="body1"> {node.label}</Typography>
                            </CardContent>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </>
    );
}

export default Tree;
