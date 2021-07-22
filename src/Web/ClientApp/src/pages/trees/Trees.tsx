import { useQueryStore } from "../../query-store/query-store";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import styled from "styled-components";
import { CircularProgress } from "@material-ui/core";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Trees() {
    const {
        trees: { useGetTrees },
    } = useQueryStore();

    const { data } = useGetTrees();

    if (!data) return <CircularProgress />;

    return (
        <>
            {data.map((p) => (
                <StyledCard key={p.uuid}>
                    <CardContent>{p.label}</CardContent>
                </StyledCard>
            ))}
        </>
    );
}

export default Trees;
