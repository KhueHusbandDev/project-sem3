import { useForm } from "react-hook-form";
import { FloatingInput } from "../../component/FloatingInput";
import { FloatingSelect } from "../../component/FloatingSelect";
import { FloatingDate } from "../../component/FloatingDate";
import { ActionIcon, Button } from "@mantine/core";
import { IconDownload, IconX } from "@tabler/icons-react";

export const EditInformation = ({ userId, onClose }) => {
  const { register, control, setValue, watch } = useForm({
    mode: "onChange",
    defaultValues: {},
  });

  const isEmployed = watch("workStatus") && watch("workStatus") === "Employed";

  return (
    <>
      <form>
        <div className="flex flex-col flex-nowrap p-4 w-full h-full gap-8">
          <ActionIcon
            className="bg-transparent text-slate-400 self-end"
            onClick={() => onClose()}
          >
            <IconX />
          </ActionIcon>
          <div className="flex flex-row justify-between gap-6">
            <FloatingInput
              className="w-1/3 h-14"
              label="Full Name"
              {...register("fullName")}
            />
            <FloatingSelect
              className="w-1/3 h-14"
              label="Gender"
              selections={["Male", "Female", "Other"]}
              {...register("gender")}
            />
            <FloatingDate
              className="w-1/3 h-14"
              label="DOB"
              {...register("dob")}
            />
          </div>
          <div className="flex flex-row justify-between gap-6">
            <FloatingInput
              className="w-1/3 h-14"
              label="Email"
              {...register("email")}
            />
            <FloatingInput
              className="w-1/3 h-14"
              label="Address"
              {...register("address")}
            />
            <FloatingSelect
              className="w-1/3 h-14"
              label="Marital Status"
              selections={["Marriaged", "Single"]}
              {...register("maritalStatus")}
            />
          </div>
          <div className="flex flex-row justify-between gap-6">
            <FloatingInput
              className="w-1/3 h-14"
              label="Hobbies"
              {...register("hobbies")}
            />
            <FloatingInput
              className="w-1/3 h-14"
              label="Likes"
              {...register("like")}
            />
            <FloatingInput
              className="w-1/3 h-14"
              label="Dislikes"
              {...register("dislike")}
            />
          </div>
          <div className="flex flex-row justify-between gap-12">
            <FloatingInput
              className="w-1/2 h-14"
              label="Cuisines"
              {...register("cuisines")}
            />
            <FloatingInput
              className="w-1/2 h-14"
              label="Sports"
              {...register("sports")}
            />
          </div>
          <div className="flex flex-row justify-between gap-6">
            <FloatingInput
              className="w-1/3 h-14"
              label="Qualification"
              {...register("qualification")}
            />
            <FloatingInput
              className="w-1/3 h-14"
              label="School"
              {...register("school")}
            />
            <FloatingSelect
              className="w-1/3 h-14"
              label="Work Status"
              selections={["Employed", "Unemployed", "Student"]}
              {...register("workStatus")}
            />
          </div>
          <div className="flex flex-row justify-between gap-6">
            <FloatingInput
              className="w-1/2 h-14"
              label="Organization"
              {...register("organization")}
              disabled={!isEmployed}
            />
            <FloatingInput
              className="w-1/2 h-14"
              label="Designation"
              {...register("designation")}
            />
          </div>
          <Button
            className="w-36 h-11 text-white"
            leftSection={<IconDownload />}
          >
            Save
          </Button>
        </div>
      </form>
    </>
  );
};
