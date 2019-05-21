function Light

close all
clear
clc

% Variables
period = 0.3;
dt = 0.01;
time = [0:dt:period];

figure('Renderer', 'painters', 'Position', [5 5 220 300]);
y = 0.0;
line([0.3, 1], [y,y]);

hold on

lightIllusionRampup = ((-1) / 0.3)*time+1;

plot(time, lightIllusionRampup);

title('Light Illusion Range Rampup');
ylabel('Normalised Light Range');
xlabel('Normalised Distance From Subject');

ylim([-0.1, 1])
xticks([0 1])
xticklabels({'d_0','d_1'})
yticks([0 1])
yticklabels({'l_0','l_1'})


