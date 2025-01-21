<template>
  <VOverlay
    v-model="globalSearch.opened.value"
    class="align-center justify-center"
  >
    <VCard
      class="pa-5"
    >
      <h4 class="text-h4 mb-5 px-16">Global Search</h4>
      <VTextField
        label="Search"
        variant="solo-filled"
      />
    </VCard>
  </VOverlay>
</template>

<script setup lang="ts">
import useGlobalSearch from "@/hooks/globalSearch";

const globalSearch = useGlobalSearch();
</script>

<style scoped>

</style>
