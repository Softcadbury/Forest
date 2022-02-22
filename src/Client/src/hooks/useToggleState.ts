import { useCallback, useState } from "react";

export const useToggleState = (defaultValue: boolean = false): [boolean, () => void] => {
    const [value, setValue] = useState(defaultValue);
    return [value, useCallback(() => setValue(!value), [value])];
};
