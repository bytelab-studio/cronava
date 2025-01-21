<template>
  <VListItem
    :active="active"
    class="user-select-none"
  >
    <div class="py-3">
      <span class="font-weight-bold user-select-none">{{ subject }}</span>
      <div class="d-flex justify-space-between px-1">
        <span class="text-disabled text-caption">{{ sender }}</span>
        <span class="font-italic text-caption">{{ received.format(config.dateFormat.value) }}</span>
      </div>
    </div>
  </VListItem>
</template>

<script setup lang="ts">
import {type Moment} from "moment";
import {useConfig} from "@/hooks/config";

const config = useConfig();

defineProps<{
  subject: string;
  received: Moment;
  sender: string;
  active?: boolean;
}>();
</script>

<style scoped>

</style>
