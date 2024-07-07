import { ActionIcon, Tooltip } from "@mantine/core";
import { IconArrowBack, IconArrowLeft } from "@tabler/icons-react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import { FloatingInput } from "../component/FloatingInput";
import { FloatingDate } from "../component/FloatingDate";
import { FloatingSelect } from "../component/FloatingSelect";

export const Register = () => {
  const { register, handleSubmit } = useForm({
    mode: "onChange",
  });
  const navigate = useNavigate();
  const onRegister = async (data) => {};
  return (
    <>
      <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
        <div className="sm:mx-auto sm:w-full sm:max-w-sm">
          <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
            Register for registration
          </h2>
        </div>

        <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
          <form className="space-y-6" onSubmit={handleSubmit(onRegister)}>
            <FloatingInput label="Full Name" {...register("fullName")} />
            <FloatingInput label="Phone Number" {...register("phoneNumber")} />
            <FloatingInput label="Password" {...register("password")} />
            <FloatingInput
              label="Confirm Password"
              {...register("confirmPassword")}
            />
            <FloatingDate lable="dob" {...register("dob")} />
            <FloatingSelect
              label="Gender"
              selections={["Male", "Female", "Other"]}
              {...register("gender")}
            />
            <FloatingInput label="Email" {...register("email")} />

            <div>
              <button
                type="submit"
                className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
              >
                Register
              </button>
            </div>
            <ActionIcon
              className="rounded-full bg-indigo-600 text-white"
              about="Back To Login"
              onClick={() => navigate("/")}
            >
              <IconArrowLeft size={50} />
            </ActionIcon>
          </form>
        </div>
      </div>
    </>
  );
};
