import { useQueryStore } from "./query-store/query-store";

function App() {
    const {
        trees: { useGetTrees },
    } = useQueryStore();

    const { data } = useGetTrees();

    return !data ? (
        <></>
    ) : (
        <>
            {data.map((p) => (
                <div key={p.uuid}>{p.label}</div>
            ))}
        </>
    );
}

export default App;
