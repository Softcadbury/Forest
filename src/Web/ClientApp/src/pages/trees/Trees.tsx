import { useQueryStore } from "../../query-store/query-store";
import styled from "styled-components";
import { Button, CircularProgress, CardContent, Card } from "@material-ui/core";

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
                <StyledCard key={p.uuid}>
                    <CardContent>
                        <Button href={"/trees/" + p.uuid}>{p.label}</Button>
                    </CardContent>
                </StyledCard>
            ))}
        </>
    );
}

export default Trees;
