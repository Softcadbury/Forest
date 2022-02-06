import { useQueryStore } from "../../stores/queryStore";
import { Button, CircularProgress, CardContent, Card, Grid, Typography } from "@mui/material";
import AddTreeModal from "./modals/AddTreeModal";
import useBooleanState from "../../hooks/useBooleanState";
import { useResources } from "../../hooks/useResources";
import AddIcon from "@mui/icons-material/Add";

function Trees() {
    const resources = useResources();

    const { treeStore } = useQueryStore();
    const { data: trees } = treeStore.useGetAll();

    const [isAddTreeModalOpen, showAddTreeModal, hideAddTreeModal] = useBooleanState(false);

    if (!trees) return <CircularProgress />;

    return (
        <>
            <Typography variant="h6" sx={{ marginBottom: 1 }}>
                {resources.common_Trees}
                <Button onClick={showAddTreeModal} sx={{ marginLeft: 3 }} startIcon={<AddIcon />}>
                    {resources.common_Add}
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
