import { useQueryStore } from "../../query-store/query-store";
import styled from "styled-components";
import { Button, CircularProgress, CardContent, Card } from "@material-ui/core";
import AddTreeModal from "./modals/AddTreeModal";
import useBooleanState from "../../hooks/useBooleanState";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Trees() {
    const { treeStore } = useQueryStore();
    const { data: trees } = treeStore.useGetAll();

    const [isAddTreeModalOpen, showAddTreeModal, hideAddTreeModal] = useBooleanState(false);

    if (!trees) return <CircularProgress />;

    return (
        <>
            {trees.map((tree) => (
                <StyledCard key={tree.id}>
                    <CardContent>
                        <Button href={"/trees/" + tree.id}>{tree.label}</Button>
                    </CardContent>
                </StyledCard>
            ))}
            <StyledCard>
                <CardContent>
                    <Button onClick={showAddTreeModal}>+ Add</Button>
                </CardContent>
            </StyledCard>
            <AddTreeModal isOpen={isAddTreeModalOpen} handleClose={hideAddTreeModal} />
        </>
    );
}

export default Trees;
