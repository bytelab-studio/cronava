<template>
  <VNavigationDrawer
    v-model="drawer"
    :rail="config.sidebarCollapsed.value"
    permanent
    floating
  >
    <VListItem
      prepend-avatar="/src/assets/logo.png"
      title="Cronava"
      nav
      @click="config.sidebarCollapsed.value = false"
    >
      <template v-slot:append>
        <VBtn
          icon="mdi-chevron-left"
          variant="text"
          @click.stop="config.sidebarCollapsed.value = true"
        />
      </template>
    </VListItem>
    <VList
      density="compact" nav
    >
      <VListItem
        prepend-icon="mdi-inbox"
        title="Inbox"
        value="Inbox"
        :active="router.isActive('inbox')"
        @click="router.navigateTo('inbox')"
      />
      <VListItem
        prepend-icon="mdi-star"
        title="Starred"
        value="starred"
        :active="router.isActive('starred')"
        @click="router.navigateTo('starred')"
      />
    </VList>

    <template v-slot:append>
      <VList>
        <VListItem
          prepend-icon="mdi-cog-outline"
          title="Settings"
          value="settings"
          :active="router.isActive('settings')"
          @click="router.navigateTo('settings')"
        />
      </VList>
    </template>
  </VNavigationDrawer>
</template>

<script setup lang="ts">

import {ref} from "vue";
import useRouter from "@/hooks/router";
import {useConfig} from "@/hooks/config";

const router = useRouter();
const config = useConfig();

const drawer = ref<boolean>(true);

</script>

<style scoped>

</style>
