import { useState, useCallback } from "react";

export const useBooleanState = (
    defaultValue: boolean = false
): [value: boolean, setTrue: () => void, setFalse: () => void] => {
    const [value, setValue] = useState(defaultValue);
    return [value, useCallback(() => setValue(true), []), useCallback(() => setValue(false), [])];
};
