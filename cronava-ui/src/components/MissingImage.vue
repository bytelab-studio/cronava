

<template>
  <VImg
    class="pointer-none"
    width="500"
    :src="`/src/assets/missings/missing_${id}.png`"
    aspect-ratio="16/9"
    cover
  />
</template>

<script setup lang="ts">
function getRndInteger(min: number, max: number): number {
  return Math.floor(Math.random() * (max - min) ) + min;
}

const id: number = getRndInteger(1, 1);
</script>

<style scoped>

</style>
