import { faker } from "@faker-js/faker";
import { FloatingDate } from "../../component/FloatingDate";
import { FloatingInput } from "../../component/FloatingInput";
import { FloatingSelect } from "../../component/FloatingSelect";
import { InfoField } from "../../component/InfoField";
import { EditInformation } from "./EditInformation";
import { useForm } from "react-hook-form";

export const Infomation = ({ isEdit, onClose }) => {
  return (
    <div className="flex flex-col">
      {isEdit ? (
        <EditInformation onClose={onClose} />
      ) : (
        <>
          <div className="flex flex-col flex-nowrap p-4 w-full h-full gap-8">
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Full Name"
                value={faker.person.fullName()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="Gender"
                value={faker.person.gender()}
              />
            </div>
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Email"
                value={faker.internet.email()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="Address"
                value={faker.location.streetAddress().toString()}
              />
            </div>
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Marital Status"
                value={faker.person.bio()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="DOB"
                value={faker.date.past().toDateString()}
              />
            </div>
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Hobbies"
                value={faker.person.bio()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="Likes"
                value={faker.person.bio()}
              />
            </div>
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Qualification"
                value={faker.person.bio()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="School"
                value={faker.person.bio()}
              />
            </div>
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Organization"
                value={faker.person.bio()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="Designation"
                value={faker.person.bio()}
              />
            </div>

            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Work Status"
                value={faker.person.bio()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="Dislikes"
                value={faker.person.bio()}
              />
            </div>
            <div className="flex flex-row justify-between gap-12">
              <InfoField
                className="w-1/2 h-14"
                label="Cuisines"
                value={faker.person.bio()}
              />
              <InfoField
                className="w-1/2 h-14"
                label="Sports"
                value={faker.person.bio()}
              />
            </div>
          </div>
        </>
      )}
    </div>
  );
};
