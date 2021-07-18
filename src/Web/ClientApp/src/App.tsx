import { useQueryStore } from "./query-store/query-store";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import styled from "styled-components";
import { CircularProgress } from "@material-ui/core";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function App() {
    const {
        trees: { useGetTrees },
    } = useQueryStore();

    const { data } = useGetTrees();

    return !data ? (
        <CircularProgress />
    ) : (
        <>
            {data.map((p) => (
                <StyledCard key={p.uuid}>
                    <CardContent>{p.label}</CardContent>
                </StyledCard>
            ))}
        </>
    );
}

export default App;