import { TextField } from "@mui/material";
import { Controller, UseControllerProps } from "react-hook-form";

export function FormInputText<T>({ name, control, rules, label }: UseControllerProps<T> & { label: string}) {
    return (
        <Controller
            name={name}
            control={control}
            rules={rules}
            render={({ field: { onChange, value }, fieldState: { error } }) => (
                <TextField
                    helperText={error ? error.message : null}
                    size="small"
                    error={!!error}
                    onChange={onChange}
                    value={value}
                    fullWidth
                    label={label}
                    variant="outlined"
                />
            )}
        />
    );
}
