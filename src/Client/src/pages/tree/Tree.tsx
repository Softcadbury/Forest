import { CardContent, Card, Typography, Grid } from "@mui/material";
import { useParams } from "react-router-dom";
import { useQueryStore } from "../../stores/queryStore";
import { useCallback } from "react";
import { NodePost } from "../../services/generatedServices";
import { Loader } from "../../common/components";
import { TreeHeader } from "../../common/components/headers/TreeHeader";

const Tree: React.FC = () => {
    var params = useParams<{ id: string }>();
    const { treeStore, treeNodeStore } = useQueryStore();
    const { data: tree } = treeStore.useGet(params.id);
    const { data: nodes } = treeNodeStore.useGetAll(tree?.id);
    const { mutate: onCreateNode } = treeNodeStore.useCreate();

    const onClickCreateNode = useCallback(() => {
        var node = new NodePost({ label: "node" });
        tree?.id && onCreateNode({ treeId: tree.id, node });
    }, [onCreateNode, tree]);

    if (!tree || !nodes) return <Loader />;

    return (
        <div>
            <TreeHeader onAdd={onClickCreateNode} treeLabel={tree.label} />
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
        </div>
    );
};

export default Tree;
