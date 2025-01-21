import {ref} from "vue";
import hotkeys from "hotkeys-js";
import {useConfig} from "@/hooks/config";

const config = useConfig();
const opened = ref<boolean>(false);

export default function useGlobalSearch() {
  function openSearch() {
    opened.value = true;
  }

  return {
    opened,
    openSearch
  }
}

hotkeys(config.openGlobalSearch.value, () => {
  opened.value = true;
});
