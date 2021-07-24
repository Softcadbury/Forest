import { CircularProgress, CardContent, Card } from "@material-ui/core";
import styled from "styled-components";
import { useRouteMatch } from "react-router-dom";
import { useQueryStore } from "../../query-store/query-store";

const StyledCard = styled(Card)`
    max-width: 300px;
`;

function Tree() {
    const match = useRouteMatch<{ uuid: string }>("/trees/:uuid");
    const uuid = match?.params.uuid;

    const { treesStore } = useQueryStore();
    const { data } = treesStore.useGet(uuid);

    if (!data) return <CircularProgress />;

    return (
        <StyledCard>
            <CardContent>{data.label}</CardContent>
        </StyledCard>
    );
}

export default Tree;
