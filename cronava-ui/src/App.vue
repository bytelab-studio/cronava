<template>
  <VResponsive>
    <VApp>
      <Navigation/>
      <VMain>
        <component :is="router.activePage.value"></component>
        <GlobalSearch />
      </VMain>
    </VApp>
  </VResponsive>
</template>

<script setup lang="ts">
import Navigation from "@/components/Navigation.vue";
import useRouter from "@/hooks/router";
import GlobalSearch from "@/components/GlobalSearch.vue";

const router = useRouter();
</script>

<style>

.user-select-none {
  user-select: none;
}

.pointer-none {
  pointer-events: none;
}

</style>
