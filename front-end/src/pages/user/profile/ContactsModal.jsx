import { Button, Modal } from "@mantine/core";
import { useForm } from "react-hook-form";
import { FloatingInput } from "../../component/FloatingInput";

export const ContactModals = ({ isOpen, onClose }) => {
  const { register, handleSubmit } = useForm({
    mode: "onChange",
  });

  const onAddContact = (data) => {
    console.log(data);
  };

  return (
    <Modal opened={isOpen} onClose={onClose} title="Add New Contact">
      <form onSubmit={handleSubmit(onAddContact)}>
        <div className="flex flex-col gap-4">
          <FloatingInput label="Full Name" {...register("fullName")} />
          <FloatingInput label="Phone Number" {...register("phoneNumber")} />
          <Button type="submit">Add Contact</Button>
        </div>
      </form>
    </Modal>
  );
};
