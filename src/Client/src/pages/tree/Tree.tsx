import { CardContent, Card, Typography, Grid, FormGroup, FormControlLabel, Switch } from "@mui/material";
import { useParams } from "react-router-dom";
import { useQueryStore } from "../../stores/queryStore";
import { useCallback } from "react";
import { NodePost } from "../../services/generatedServices";
import { Loader } from "../../common/components";
import { TreeHeader } from "../../common/components/headers/TreeHeader";
import { useToggleState } from "../../hooks";

const Tree: React.FC = () => {
    var params = useParams<{ id: string }>();
    const { treeStore, treeNodeStore } = useQueryStore();
    const { data: tree } = treeStore.useGet(params.id);
    const { data: nodes } = treeNodeStore.useGetAll(tree?.id); // todo - do not load both nodes and nodesInText at the same time
    const { data: nodesInText } = treeNodeStore.useGetPrettyPrint(tree?.id);
    const { mutate: onCreateNode } = treeNodeStore.useCreate();

    const [showNodesAsText, toggleShowNodesAsText] = useToggleState();

    const onClickCreateNode = useCallback(() => {
        var node = new NodePost({ label: "node" });
        tree?.id && onCreateNode({ treeId: tree.id, node });
    }, [onCreateNode, tree]);

    if (!tree || !nodes || !nodesInText) return <Loader />;

    return (
        <div>
            <TreeHeader onAdd={onClickCreateNode} treeLabel={tree.label} />
            <FormGroup sx={{ mb: 3 }}>
                <FormControlLabel
                    control={<Switch checked={showNodesAsText} onChange={toggleShowNodesAsText} />}
                    label="Show nodes as text" // todo - add resource
                />
            </FormGroup>
            {showNodesAsText && <Typography component="pre">{nodesInText?.text}</Typography>}
            {!showNodesAsText && (
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
            )}
        </div>
    );
};

export default Tree;
