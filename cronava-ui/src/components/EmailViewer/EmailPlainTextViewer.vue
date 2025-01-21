<template>
  <pre class="text-pre-wrap">{{ content }}</pre>
</template>

<script setup lang="ts">
defineProps<{
  content: string;
}>();
</script>


<style scoped>

</style>
