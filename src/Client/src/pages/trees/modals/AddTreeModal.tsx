import { Box, Button, FormControl, Input, InputLabel, Modal } from "@material-ui/core";

interface AddTreeModalProperties {
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

function AddTreeModal({ isOpen, handleClose }: AddTreeModalProperties) {
    return (
        <Modal
            open={isOpen}
            onClose={handleClose}
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
        >
            <Box sx={style}>
                <FormControl>
                    <InputLabel htmlFor="my-input">Name</InputLabel>
                    <Input id="my-input" aria-describedby="my-helper-text" />
                </FormControl>
                <Button>+ Add</Button>
            </Box>
        </Modal>
    );
}

export default AddTreeModal;
