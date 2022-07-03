import { useQueryStore } from "../../stores/queryStore";
import { Button, CardContent, Card, Grid } from "@mui/material";
import { useBooleanState } from "../../hooks";
import { Loader } from "../../common/components";
import AddTreeModal from "./modals/AddTreeModal";
import { TreeHeader } from "../../common/components/headers/TreeHeader";

const Trees: React.FC = () => {
    const { treeStore } = useQueryStore();
    const { data: trees } = treeStore.useGetAll();

    const [isAddTreeModalOpen, showAddTreeModal, hideAddTreeModal] = useBooleanState(false);

    if (!trees) return <Loader />;

    return (
        <div>
            <TreeHeader onAdd={showAddTreeModal} />
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
        </div>
    );
};

export default Trees;
