import { TextField } from "@mui/material";
import { Controller, UseControllerProps } from "react-hook-form";

type FormInputTextProps<T> = UseControllerProps<T> & { label: string };

export const FormInputText = <T extends {}>({ name, control, rules, label }: FormInputTextProps<T>) => {
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
};
