import { useRouteMatch } from "react-router-dom";

function Tree() {
    const match = useRouteMatch<{ uuid: string }>("/trees/:uuid");

    const uuid = match?.params.uuid;

    return <>{uuid}</>;
}

export default Tree;
