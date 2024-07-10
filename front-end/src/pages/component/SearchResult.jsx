import { ActionIcon, Avatar, Paper, Skeleton } from "@mantine/core";
import { IconCirclePlus } from "@tabler/icons-react";

export const SearchResult = ({
  type,
  isLoading,
  searchResults,
  onSelect,
  search,
}) => {
  return (
    <div
      className={`${
        search
          ? "scrollbar-hide overflow-y-scroll h-[250px] mb-5 bg-[#fff] flex flex-col gap-y-3 pt-3"
          : "hidden"
      }`}
    >
      {isLoading ? (
        <Skeleton height={55} count={3} />
      ) : searchResults.length > 0 ? (
        searchResults?.map((user) => {
          return (
            <Paper
              h={45}
              shadow="md"
              key={user.id}
              className="flex flex-row items-center gap-x-2 p-2"
            >
              <Avatar src={user.profilePic} size={30} />
              <div>{user.name}</div>
              <div className="flex-grow" />
              <ActionIcon
                className="bg-transparent rounded-full hover:bg-slate-200"
                onClick={onSelect}
              >
                <IconCirclePlus
                  color="blue"
                  className="place-self-center"
                  size={15}
                />
              </ActionIcon>
            </Paper>
          );
        })
      ) : (
        <span className="text-[13px]">No results found</span>
      )}
    </div>
  );
};
