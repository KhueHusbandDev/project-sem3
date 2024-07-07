import clsx from "clsx";
import { forwardRef } from "react";

export const FloatingSelect = forwardRef(
  ({ inputId, label, className, selections, ...props }, ref) => (
    <>
      <div className={clsx("relative", className)}>
        <select
          id={inputId ? inputId : label}
          ref={ref}
          className="block rounded-lg px-2.5 pb-2.5 pt-5 w-full text-sm text-gray-900 bg-gray-50 dark:bg-gray-700 border border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer cursor-pointer"
          {...props}
        >
          {selections.map((select) => {
            return (
              <option value={select} key={select}>
                {select}
              </option>
            );
          })}
        </select>
        <label
          htmlFor={inputId ? inputId : label}
          className="absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-4 scale-75 top-4 z-10 origin-[0] start-2.5 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-4 rtl:peer-focus:translate-x-1/4 rtl:peer-focus:left-auto"
        >
          {label}
        </label>
      </div>
    </>
  )
);
