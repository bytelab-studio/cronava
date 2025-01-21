import {shallowRef} from "vue";

type Pages = "inbox" | "starred" | "settings";

const pages = shallowRef<{ [page in Pages]?: any }>({});
const activePage = shallowRef<any>(null);

export default function useRouter() {
  function addPage(name: Pages, component: any): void {
    pages.value[name] = component;
  }

  function navigateTo(name: Pages): void {
    if (!(name in pages.value)) {
      throw "No component is register with the name: " + name;
    }

    activePage.value = pages.value[name];
  }

  function isActive(name: Pages): boolean {
    return activePage.value == pages.value[name];
  }

  return {
    addPage,
    navigateTo,
    isActive,
    activePage
  }
}
