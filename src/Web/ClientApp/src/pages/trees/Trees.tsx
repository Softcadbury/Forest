import { useQueryStore } from "../../query-store/query-store";
import styled from "styled-components";
import { Button, CircularProgress, CardContent, Card } from "@material-ui/core";
import AddTree from "./add/AddTree";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Trees() {
    const { treesStore } = useQueryStore();
    const { data } = treesStore.useGetAll();

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
                    <Button href="/trees/add">+ Add</Button>
                </CardContent>
            </StyledCard>
            <AddTree />
        </>
    );
}

export default Trees;
