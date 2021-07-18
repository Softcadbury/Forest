import { useQueryStore } from "./query-store/query-store";

function App() {
    const {
        trees: { useGetTrees },
    } = useQueryStore();

    const { data } = useGetTrees();

    console.log(data);

    return <div>hello world</div>;
}

export default App;
