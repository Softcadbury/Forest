import { useQueryStore } from "../../query-store/query-store";
import styled from "styled-components";
import { Button, CircularProgress, CardContent, Card } from "@material-ui/core";
import AddTreeModal from "./modals/AddTreeModal";
import useBooleanState from "../../hooks/useBooleanState";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Trees() {
    const { treesStore } = useQueryStore();
    const { data } = treesStore.useGetAll();

    const [isAddTreeModalOpen, showAddTreeModal, hideAddTreeModal] = useBooleanState(false);

    if (!data) return <CircularProgress />;

    return (
        <>
            {data.map((p) => (
                <StyledCard key={p.id}>
                    <CardContent>
                        <Button href={"/trees/" + p.id}>{p.label}</Button>
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
