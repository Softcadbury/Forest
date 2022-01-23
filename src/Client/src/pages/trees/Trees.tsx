import { useQueryStore } from "../../stores/queryStore";
import { Button, CircularProgress, CardContent, Card, Grid, Typography } from "@mui/material";
import AddTreeModal from "./modals/AddTreeModal";
import useBooleanState from "../../hooks/useBooleanState";

function Trees() {
    const { treeStore } = useQueryStore();
    const { data: trees } = treeStore.useGetAll();

    const [isAddTreeModalOpen, showAddTreeModal, hideAddTreeModal] = useBooleanState(false);

    if (!trees) return <CircularProgress />;

    return (
        <>
            <Typography variant="h6" sx={{ marginBottom: 1 }}>
                Trees
                <Button onClick={showAddTreeModal} sx={{ float: "right" }}>
                    + Add
                </Button>
            </Typography>
            <Grid container spacing={2}>
                {trees.map((tree) => (
                    <Grid item xs={3} md={3} key={tree.id}>
                        <Card>
                            <CardContent>
                                <Button href={"/trees/" + tree.id}>{tree.label}</Button>
                            </CardContent>
                        </Card>
                    </Grid>
                ))}
            </Grid>
            <AddTreeModal isOpen={isAddTreeModalOpen} handleClose={hideAddTreeModal} />
        </>
    );
}

export default Trees;
