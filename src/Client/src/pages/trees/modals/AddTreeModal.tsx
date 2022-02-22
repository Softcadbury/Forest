import { Box, Button, Modal } from "@mui/material";
import { useForm } from "react-hook-form";
import { useQueryStore } from "../../../stores/queryStore";
import { TreePost } from "../../../services/generatedServices";
import { useResources } from "../../../hooks/useResources";
import AddIcon from "@mui/icons-material/Add";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { FormInputText } from "../../../common/components";

interface AddTreeModalProps {
    isOpen: boolean;
    handleClose: () => void;
}

const style = {
    position: "absolute",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    width: 400,
    bgcolor: "background.paper",
    border: "2px solid #000",
    boxShadow: 24,
    p: 4,
};

interface IFormInput {
    label: string;
}

const AddTreeModal: React.FC<AddTreeModalProps> = ({ isOpen, handleClose }) => {
    const resources = useResources();

    const { treeStore } = useQueryStore();
    const { mutate: onCreateTree } = treeStore.useCreate();

    const schema = yup.object({ label: yup.string().label(resources.common_Label).required().max(200) }).required();

    const { control, handleSubmit } = useForm<IFormInput>({
        resolver: yupResolver(schema),
    });

    const onSubmit = (data: IFormInput) => {
        var tree = new TreePost({ label: data.label });
        onCreateTree(tree);
        handleClose();
    };

    return (
        <Modal
            open={isOpen}
            onClose={handleClose}
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
        >
            <Box sx={style}>
                <FormInputText
                    name="label"
                    control={control}
                    label={resources.common_Label}
                    rules={{
                        required: true,
                        maxLength: 199,
                    }}
                />
                <Button
                    onClick={handleSubmit(onSubmit)}
                    variant={"contained"}
                    sx={{ marginTop: 2 }}
                    startIcon={<AddIcon />}
                >
                    {resources.common_Add}
                </Button>
            </Box>
        </Modal>
    );
};

export default AddTreeModal;
