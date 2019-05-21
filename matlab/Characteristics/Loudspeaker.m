function Loudspeaker

close all
clear
clc

% Variables
period = 2;
dt = 0.01;
time = [0:dt:period];
tau = time/period;

%% Plot 1: Loudspeaker Volume

% Train Speaker
figure('Renderer', 'painters', 'Position', [5 5 300 200]);
y = 0.4;
line([0,1], [y,y]);
hold on

% Loudspeaker
loudspeakerVolume = 0.8*tau + 0.2;
plot(tau, loudspeakerVolume);

title('Train and Loudspeaker Characteristics');
legend('Train', 'Loudspeaker', 'Location', 'northwest');
ylabel('Volume');
xlabel('Time');

ylim([0, 1])
xticks([0 1])
xticklabels({'t_0','t_1'})
yticks([0 0.2 0.4 1])
yticklabels({'0', 'V_{L0}','V_T', 'V_{L1}, 1'})

%% Plot 2: Loudness

trainLoudness = 0.4 * tau;
loudspeakerLoudness = 0.8 * tau + 0.1757;

figure('Renderer', 'painters', 'Position', [5 5 300 200]);
plot(tau, trainLoudness);
hold on
plot(tau, loudspeakerLoudness);

title('Perceived Loudness of Train and Loudspeaker');
legend('Train', 'Loudspeaker', 'Location', 'northwest');
ylabel('Perceived Volume');
xlabel('Time');

ylim([0, 1])
xticks([0 1])
xticklabels({'t_0','t_1'})
yticks([0 0.1757 0.4 0.9757 1])
yticklabels({'V_{T0}, 0', 'V_{L0}', 'V_{T1}', 'V_{L1}', '1'})


%% Plot 3: Listener

% Variables
yaxis = -tau+1;
figure('Renderer', 'painters', 'Position', [5 5 300 200]);
plot(tau, yaxis);

ylim([0, 1])
xticks([0 1])
xticklabels({'d_0','d_1'})
yticks([0 1])

title('Volume Rolloff');
ylabel('Normalised Perceived Volume');
xlabel('Distance From Audio Source');

