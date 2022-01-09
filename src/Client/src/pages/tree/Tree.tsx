import { CircularProgress, CardContent, Card } from "@material-ui/core";
import styled from "styled-components";
import { useRouteMatch } from "react-router-dom";
import { useQueryStore } from "../../query-store/query-store";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Tree() {
    const match = useRouteMatch<{ id: string }>("/trees/:id");
    const id = match?.params.id;

    const { treesStore } = useQueryStore();
    const { data } = treesStore.useGet(id);

    if (!data) return <CircularProgress />;

    return (
        <StyledCard>
            <CardContent>{data.label}</CardContent>
        </StyledCard>
    );
}

export default Tree;
