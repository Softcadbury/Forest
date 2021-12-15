import { useCallback, useState } from "react";

function useToggleState(defaultValue: boolean = false): [boolean, () => void] {
    const [value, setValue] = useState(defaultValue);
    return [value, useCallback(() => setValue(!value), [value])];
}

export default useToggleState;
