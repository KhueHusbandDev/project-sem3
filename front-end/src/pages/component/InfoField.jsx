import clsx from "clsx";

export const InfoField = ({ inputId, label, className, value }) => {
  return (
    <>
      <div className={clsx("flex flex-col", className)}>
        <label
          htmlFor={inputId}
          className="text-md text-slate-400 font-normal self-start"
        >
          {label}
        </label>
        <span className="text-md text-black font-medium self-start">
          {value}
        </span>

      </div>
    </>
  );
};
