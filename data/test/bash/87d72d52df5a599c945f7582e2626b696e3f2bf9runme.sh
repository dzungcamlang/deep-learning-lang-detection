#!/bin/bash
for sample in 001 002 003 004 005 006 007 008 009 010 011 012 013 014 015 016 017 018 019 020 021 022 023 024 025 026 027 028 AB4AA001 CAM9 D1AAB4AA001 D1AAC9AA001 D1AAD9AA001 D1AAE3AA001 D1AAF4AA001 D1AAU3AA001 D1AAV1AA001 D1AAV2AA001 D1AAW3AA001 D1CAU6AA001 D1CAU7AA001 D1CAV1AA001 D1CAV7AA001 D1CAV8AA001 D1CAV9AA001 D1CAW1AA001 D1CAX4AA001 D1CAX7AA001 D1DAD1AA002
do
  ./gatk.sh  ../../$sample/bam/$sample.bam hg19.fa /molbio/projects/SNP/human/julcsiwork/dbSNP137/dbsnpforgatk.vcf $sample.vcf >$sample.out 2>$sample.err
done
