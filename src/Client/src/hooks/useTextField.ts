import { ChangeEvent, useState } from "react";

export type InputChangeCallbackType = (event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;

export function useTextField(
    initialValue: string = ""
): [value: string, setValue: React.Dispatch<React.SetStateAction<string>>, onChangeCallback: InputChangeCallbackType] {
    const [value, setValue] = useState(initialValue);

    const onChangeCallback = (event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        setValue(event.currentTarget.value);
    };

    return [value, setValue, onChangeCallback];
}
